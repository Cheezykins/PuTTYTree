using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using PuTTYTree.Properties;

namespace PuTTYTree
{
    /// <summary>
    /// 
    /// </summary>
    internal class SessionCollection : List<Session>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static SessionCollection LoadSessions(string location)
        {
            var ret = new SessionCollection();

            using (var sessions = RegistryManager.getKey(Registry.CurrentUser, location))
            {
                if (sessions == null) return ret;
                foreach (var sessionKey in RegistryManager.getSubKeys(sessions))
                {
                    using (var session = RegistryManager.getKey(Registry.CurrentUser, location + sessionKey))
                    {
                        if (session == null) continue;
                        var objSession = RegistryManager.getSession(session);
                        objSession.name = sessionKey;
                        ret.Add(objSession);
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// The render.
        /// </summary>
        /// <returns>
        /// The <see cref="TreeNode"/>.
        /// </returns>
        public TreeNode Render()
        {
            var root = new TreeNode("Sessions")
            {
                ImageIndex = 0,
                Name = "Session"
            };

            root.SelectedImageIndex = root.ImageIndex;

            var directories = Settings.Default.Directories;

            foreach (var path in directories)
            {
                var currentPath = path;

                if (path.Substring(0, 8) == "Sessions")
                {
                    currentPath = path.Substring(9);
                }

                var components = currentPath.Split('\\');

                var currentDir = root;

                foreach (var component in components)
                {
                    if (currentDir.Nodes[component] != null)
                    {
                        currentDir = currentDir.Nodes[component];
                    }
                    else
                    {
                        currentDir = currentDir.Nodes.Add(component);
                        currentDir.ImageIndex = 2;
                        currentDir.Name = component;
                        currentDir.SelectedImageIndex = currentDir.ImageIndex;
                    }
                }
            }

            foreach (var session in this)
            {
                var cleanName = session.cleanName();

                var path =
                    session.Where(p => p.key == "TreePath").Select(p => p.value).DefaultIfEmpty(string.Empty).SingleOrDefault();

                var currentDir = root;

                if (path != string.Empty)
                {
                    if (path != null)
                    {
                        var components = path.Split('\\');

                        currentDir = components.Aggregate(currentDir, (current, component) => current.Nodes[component]);
                    }
                }

                var newNode = currentDir.Nodes.Add(cleanName);
                newNode.ImageIndex = 1;
                newNode.Name = null;
                newNode.SelectedImageIndex = newNode.ImageIndex;
            }

            return root;
        }
    }
}
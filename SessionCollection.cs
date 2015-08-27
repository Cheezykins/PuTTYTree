using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;


namespace PuTTYTree
{
    internal class SessionCollection : List<Session>
    {

        public static SessionCollection loadSessions(string location)
        {
            SessionCollection ret = new SessionCollection();

            using (RegistryKey sessions = RegistryManager.getKey(Registry.CurrentUser, location))
            {
                if (sessions != null)
                {
                    foreach (string sessionKey in RegistryManager.getSubKeys(sessions))
                    {
                        using (RegistryKey session = RegistryManager.getKey(Registry.CurrentUser, location + sessionKey))
                        {
                            if (session != null)
                            {
                                Session objSession = RegistryManager.getSession(session);
                                objSession.name = sessionKey;
                                ret.Add(objSession);
                            }
                        }

                    }
                }
            }

            return ret;
        }

        public TreeNode render()
        {

            TreeNode root = new TreeNode("Sessions");

            root.ImageIndex = 0;
            root.SelectedImageIndex = root.ImageIndex;

            StringCollection directories = Properties.Settings.Default.Directories;

            foreach (string path in directories)
            {
                string[] components = path.Split('\\');

                TreeNode currentDir = root;

                foreach (string component in components)
                {
                    

                    if (currentDir.Nodes[component] != null)
                    {
                        currentDir = currentDir.Nodes[component];
                    }
                    else
                    {
                        currentDir = currentDir.Nodes.Add(component);
                        currentDir.ImageIndex = 2;
                        currentDir.Name = path;
                        currentDir.SelectedImageIndex = currentDir.ImageIndex;
                        
                    }
                }
            }

            foreach (Session session in this)
            {

                string cleanName = session.cleanName();

                string path = session.Where(p => p.key == "TreeParent").Select(p => p.value).DefaultIfEmpty("").SingleOrDefault();

                TreeNode currentDir = root;

                if (path != "")
                {
                    string[] components = path.Split('\\');

                    foreach (string component in components)
                    {
                        currentDir = currentDir.Nodes[component];
                    }
                }

                TreeNode newNode = currentDir.Nodes.Add(cleanName);
                newNode.ImageIndex = 1;
                newNode.Name = null;
                newNode.SelectedImageIndex = newNode.ImageIndex;

            }

            return root;

        }
    }
}
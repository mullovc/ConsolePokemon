using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework.GUI;

namespace MyFramework
{
    abstract class Scene
    {
        public Window window { get; protected set; }

        public event EventHandler changed;

        public event EventHandler closeScene;

        public event SceneEventHandler addScene;

        public Scene(Window window)
        {
            this.window = window;

            window.changed += onChanged;
        }

        abstract protected void initialize();


        /**
         * tells listeners that the window has changed
         */
        protected void onChanged(object sender, EventArgs e)
        {
            if (changed != null)
            {
                changed(this, e);
            }
        }

        /**
         * tells listeners to detatch from this window and close it
         */
        protected void onCloseScene(EventArgs e)
        {
            if (closeScene != null)
            {
                closeScene(this, e);
            }
        }

        /**
         * tells listeners to open a new scene
         */
        protected void onAddScene(Scene scene)
        {
            if (addScene != null)
            {
                addScene(this, scene);
            }
        }

        abstract public void inputHandler(String key);

    }
}

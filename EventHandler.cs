using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework
{
    public delegate void EventHandler(object sender, EventArgs e);

    public delegate void KeyEventHandler(object sender, string key);//Key key);

    delegate void SceneEventHandler(object sender, Scene scene);
}

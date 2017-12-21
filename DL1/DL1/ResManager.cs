using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL1
{
    public class ResManager
    {
        private Game _game = null;
        private static ResManager _instance = null;

        public static ResManager Instance
        {
            get
            {
                if (_instance == null) 
                    _instance = new ResManager();
                return _instance;
            }
        }
        private ResManager()
        {
          
        }

        public void Initialize(Game game)
        {
            this._game = game;
        }

        public IList<Texture2D> Load(string[] filePaths)
        {
            //load texture
            List<Texture2D> texList = new List<Texture2D>();
            for(int i = 0; i < filePaths.Length; i++)
            {
                var tex = _game.Content.Load<Texture2D>(filePaths[i]);
                texList.Add(tex);
            }
            return texList;
           
          
        }
        public IList<Texture2D> Load(string filePaths)
        {

            return this.Load(new string[] { filePaths });


        }

    }
}

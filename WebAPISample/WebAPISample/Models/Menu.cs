using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.Models
{
    public class Menu
    {

        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        private Iesi.Collections.Generic.ISet<Menu> _children;

        public virtual Iesi.Collections.Generic.ISet<Menu> Children { get { return this._children; } set { this._children = value; } }

        public Menu() {
            this._children = new Iesi.Collections.Generic.HashedSet<Menu>();
        }
    }
}
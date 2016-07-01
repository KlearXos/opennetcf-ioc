﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace System.Windows.Forms
{
#if WindowsCE
    public static class FormsExtensions
    {
        public static void RemoveByKey(this Control.ControlCollection collection, string key)
        {
            if (!RemoveChildByName(collection, key))
            {
                throw new ArgumentException("Key not found");
            }
        }

        private static bool RemoveChildByName(this Control.ControlCollection collection, string name)
        {
            foreach (Control child in collection)
            {
                if (child.Name == name)
                {
                    collection.Remove(child);
                    return true;
                }

                // iterate children
                if (RemoveChildByName(child.Controls, name)) return true;
            }

            return false;
        }
    }
#endif
}

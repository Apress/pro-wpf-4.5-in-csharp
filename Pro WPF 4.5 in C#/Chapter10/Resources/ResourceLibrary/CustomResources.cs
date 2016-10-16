using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ResourceLibrary
{
    public class CustomResources
    {
        public static ComponentResourceKey SadTileBrush
        {
            get
            {
                return new ComponentResourceKey(
                    typeof(CustomResources), "SadTileBrush");
            }
        }
    }
}

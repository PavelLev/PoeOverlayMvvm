using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PoeOverlayMvvm.Utility.MVVM
{
    public static class ElementsSize {
        public static double WindowHeight { get; } = SystemParameters.PrimaryScreenHeight;
        public static double WindowWidth { get; } = SystemParameters.PrimaryScreenWidth;

        public static double ElementHeight { get; } = WindowHeight * 0.03;
        public static double MainMenuHeight { get; } = ElementHeight;
        public static double PanelWidth { get; } = WindowWidth * 0.25;
        public static double PanelItemsControlMaxHeight { get; } = WindowHeight * 0.44;//0.5 - 2xElementHeight



        public static double FontSize { get; } = ElementHeight * 0.5;
        public static Thickness ElementPadding { get; } = new Thickness(ElementHeight * 0.1);
        public static Thickness ComboBoxPadding { get; } = new Thickness(ElementHeight * 0.01);
        public static Thickness HistoryButtonThickness { get; } = new Thickness(0);

    }
}

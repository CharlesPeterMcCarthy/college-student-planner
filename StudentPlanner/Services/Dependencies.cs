using System;
using System.Windows;
using System.Windows.Media;

namespace StudentPlanner.Services {
    public static class Dependencies {

        public static T GetParentOfType<T>(DependencyObject element) where T : DependencyObject {
            Type type = typeof(T);
            if (element == null) return null;
            DependencyObject parent = VisualTreeHelper.GetParent(element);
            if (parent == null && ((FrameworkElement)element).Parent is DependencyObject)
                parent = ((FrameworkElement)element).Parent;
            if (parent == null) return null;
            else if (parent.GetType() == type || parent.GetType().IsSubclassOf(type))
                return parent as T;
            return GetParentOfType<T>(parent);
        }

    }
}

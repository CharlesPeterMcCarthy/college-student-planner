using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public static class Toastr {

        private static NotificationManager notificationManager = new NotificationManager();
        private static bool notificationsOn = false;

        public static void TurnOnNotifications() {
            notificationsOn = true;
        }

        public static void TurnOffNotifications() {
            notificationsOn = false;
        }

        public static void Info(string title, string message) {
            if (!notificationsOn) return;
            DisplayToastrNotification(new NotificationContent { Title = title, Message = message, Type = NotificationType.Information });
        }

        public static void Success(string title, string message) {
            if (!notificationsOn) return;
            DisplayToastrNotification(new NotificationContent { Title = title, Message = message, Type = NotificationType.Success });
        }

        public static void Warning(string title, string message) {
            if (!notificationsOn) return;
            DisplayToastrNotification(new NotificationContent { Title = title, Message = message, Type = NotificationType.Warning });
        }

        public static void Error(string title, string message) {
            if (!notificationsOn) return;
            DisplayToastrNotification(new NotificationContent { Title = title, Message = message, Type = NotificationType.Error });
        }

        private static void DisplayToastrNotification(NotificationContent nc) {
            if (!notificationsOn) return;
            notificationManager.Show(nc, areaName: "WindowArea");
        }

    }
}

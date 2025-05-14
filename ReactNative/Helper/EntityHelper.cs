// namespace ReactNative.Helper;
//
// public static class EntityHelper
// {
//     // Method to map the entity name to the EntityType enum
//     public static EntityType GetEntityType(string entityName)
//     {
//         return entityName switch
//         {
//             "user" => EntityType.User,
//             "project" => EntityType.Project,
//             "post" => EntityType.Post,
//             "announcement" => EntityType.Announcement,
//             "userhouse" => EntityType.UserHouse,
//             "like" => EntityType.Like,
//             "rate" => EntityType.Rate,
//             "notification" => EntityType.Notification,
//             "topic" => EntityType.Topic,
//             "usernotification" => EntityType.UserNotification,
//             "houseimage" => EntityType.HouseImage,
//             _ => EntityType.General, // Default to General if no match
//         };
//     }
//
//    
//
//
//     private static ActionType ConvertActionToNumber(string action)
//     {
//         return action.ToLower() switch
//         {
//             "insert" => ActionType.Add,
//             "update" => ActionType.Update,
//             "delete" => ActionType.Delete,
//             _ => ActionType.Unknown
//         };
//     }
//
//     private static string GetEntityDescription(EntityType entityType)
//     {
//         return entityType switch
//         {
//             EntityType.User => "المستخدم",
//             EntityType.Project => "المشروع",
//             EntityType.Post => "المنشور",
//             EntityType.Announcement => "الإعلان",
//             EntityType.UserHouse => "منزل المستخدم",
//             EntityType.Like => "إعجاب",
//             EntityType.Rate => "تقييم",
//             EntityType.Notification => "الإشعار",
//             EntityType.Topic => "الموضوع",
//             EntityType.UserNotification => "إشعار المستخدم",
//             EntityType.HouseImage => "صورة المنزل",
//             _ => "عنصر عام"
//         };
//     }
//
//     public static string GetAuditDescription(string username, string action, string entityName)
//     {
//         EntityType entityType = GetEntityType(entityName);
//         string entityDescription = GetEntityDescription(entityType);
//         ActionType actionType = ConvertActionToNumber(action);
//
//         string actionDescription = actionType switch
//         {
//             ActionType.Add => " تم إضافة",
//             ActionType.Update => "تم تحديث",
//             ActionType.Delete => "تم حذف",
//             _ => "تم تنفيذ عملية غير معروفة على"
//         };
//
//         return $"{actionDescription} {entityDescription} بواسطة {username}";
//     }
//     
//     public static string GetErrorMessage(ActionType action, EntityType entity)
//     {
//         string entityDescription = GetEntityDescription(entity);
//         string actionDescription = action switch
//         {
//             ActionType.Add => "لم يتم إضافة",
//             ActionType.Update => "لم يتم تحديث",
//             ActionType.Delete => " لم يتم حذف",
//             ActionType.Get => "لم يتم ايجاد ",
//             ActionType.GetAll => "لم يتم ايجاد ",
//             _ => "يتم تنفيذ عملية غير معروفة على"
//         };
//
//         return $"{actionDescription} {entityDescription}";
//     }
// }
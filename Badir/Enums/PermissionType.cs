namespace Badir.Enums;

public enum PermissionType
{
    ExpenseCreate = 1,
    HashtagCreate = 2,
    ExpenseImageCreate = 3,
    HouseImageCreate = 4,
    HouseImageUpdate = 5,
    HouseImageDelete = 6,
    HouseNoteUpdate = 7,
    HouseLocationUpdate = 8,
    HouseMapImageUpdate = 9,
    WorkerCreate = 10,
    WorkerUpdate = 11,
    WorkerDelete = 12,
    TenderView = 13,
    
    
    
}


public static class PermissionTypeExtensions
{
    public static string GetPermissionName(PermissionType type)
    {
        return type switch
        {
            PermissionType.ExpenseCreate => "Create Expense",
            PermissionType.HashtagCreate => "Create Hashtag",
            PermissionType.ExpenseImageCreate => "Add Expense Image",
            PermissionType.HouseImageCreate => "Add House Image",
            PermissionType.HouseImageUpdate => "Update House Image",
            PermissionType.HouseImageDelete => "Delete House Image",
            PermissionType.HouseNoteUpdate => "Update House Note",
            PermissionType.HouseLocationUpdate => "Update House Location",
            PermissionType.HouseMapImageUpdate => "Update Map Image",
            PermissionType.WorkerCreate => "Add Worker",
            PermissionType.WorkerUpdate => "Update Worker",
            PermissionType.WorkerDelete => "Delete Worker",
            PermissionType.TenderView => "View Tender",
            _ => "Unknown"
        };
    }

    public static Dictionary<string, int> GetPermissionDictionary()
    {
        return new Dictionary<string, int>
        {
            { "Create Expense", (int)PermissionType.ExpenseCreate },
            { "Create Hashtag", (int)PermissionType.HashtagCreate },
            { "Add Expense Image", (int)PermissionType.ExpenseImageCreate },
            { "Add House Image", (int)PermissionType.HouseImageCreate },
            { "Update House Image", (int)PermissionType.HouseImageUpdate },
            { "Delete House Image", (int)PermissionType.HouseImageDelete },
            { "Update House Note", (int)PermissionType.HouseNoteUpdate },
            { "Update House Location", (int)PermissionType.HouseLocationUpdate },
            { "Update Map Image", (int)PermissionType.HouseMapImageUpdate },
            { "Add Worker", (int)PermissionType.WorkerCreate },
            { "Update Worker", (int)PermissionType.WorkerUpdate },
            { "Delete Worker", (int)PermissionType.WorkerDelete },
            { "View Tender", (int)PermissionType.TenderView }
        };
    }
}

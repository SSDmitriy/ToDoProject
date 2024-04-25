namespace PetProject.Domain
{
    public enum Status
    {
        WithoutUpdate = -1,
        ToDo = 1, //default status
        InProgress = 2,
        Done = 3,
        Rejected = 0 // won't be done
    }
}
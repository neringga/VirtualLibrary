namespace VirtualLibrary.View
{
    interface IUser
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string DateOfBirth{ get; set; }
        string Password { get; set; }
    }
}

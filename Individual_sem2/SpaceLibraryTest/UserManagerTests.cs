using CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserLibrary;

namespace UserLibraryTest
{
    [TestClass]
    public class UserManagerTests
    {
        private UserManager userManager;
        private Mock<IUserDataInterface> mockUserDataInterface;

        [TestInitialize]
        public void Initialize()
        {
            mockUserDataInterface = new Mock<IUserDataInterface>();
            userManager = new UserManager(mockUserDataInterface.Object);
        }

        [TestMethod]
        public void AddEmployee_Should_AddEmployeeToDataHandler_When_EmailDoesNotExist()
        {
            // Arrange

            string firstName = "John";
            string lastName = "Doe";
            string password = "password123";
            string email = "employee@example.com";
            DateTime birthdate =  DateTime.Now.AddYears(-1);

            mockUserDataInterface.Setup(u => u.EmailAlreadyExists(email)).Returns(false);

            // Act
            userManager.AddEmployee(firstName, lastName, password, email, birthdate);

            // Assert
            mockUserDataInterface.Verify(u => u.AddUserToDatabase(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEmailException))]
        public void AddEmployee_Should_ThrowInvalidEmailException_When_EmailAlreadyExists()
        {
            // Arrange

            string firstName = "John";
            string lastName = "Doe";
            string password = "password123";
            string email = "employee@example.com";
            DateTime birthdate = DateTime.Now.AddYears(-1);

            mockUserDataInterface.Setup(u => u.EmailAlreadyExists(email)).Returns(true);

            // Act
            userManager.AddEmployee(firstName, lastName, password, email, birthdate);

            // Assert
            // Exception expected 
        }

        [TestMethod]
        public void AddAdmin_Should_AddAdminToDataHandler_When_EmailDoesNotExist()
        {
            // Arrange

            string firstName = "John";
            string lastName = "Doe";
            string password = "password123";
            string email = "admin@example.com";
            DateTime birthdate = DateTime.Now.AddYears(-1);

            mockUserDataInterface.Setup(u => u.EmailAlreadyExists(email)).Returns(false);

            // Act
            userManager.AddAdmin(firstName, lastName, password, email, birthdate);

            // Assert
            mockUserDataInterface.Verify(u => u.AddUserToDatabase(It.IsAny<Administrator>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEmailException))]
        public void AddAdmin_Should_ThrowInvalidEmailException_When_EmailAlreadyExists()
        {
            // Arrange

            string firstName = "John";
            string lastName = "Doe";
            string password = "Password123";
            string email = "admin@example.com";
            DateTime birthdate = DateTime.Now.AddYears(-1);

            mockUserDataInterface.Setup(u => u.EmailAlreadyExists(email)).Returns(true);

            // Act
            userManager.AddAdmin(firstName, lastName, password, email, birthdate);

            // Assert
            // Exception expected 
        }

        [TestMethod]
        public void GenerateRandomPassword_Should_ReturnRandomPasswordWithGivenLength()
        {
            // Arrange
            int length = 10;

            // Act
            string password = userManager.GenerateRandomPassword(length);

            // Assert
            Assert.AreEqual(length, password.Length);
        }

        [TestMethod]
        public void RemoveUser_Should_DeleteUserFromDataHandler()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string password = "password123";
            string email = "admin@example.com";
            DateTime birthdate = DateTime.Now.AddYears(-1);
            User user = new Employee(firstName, password, email, lastName, birthdate); 

            // Act

            userManager.RemoveUser(user);

            // Assert
            mockUserDataInterface.Verify(u => u.DeleteUser(user), Times.Once);
        }

        [TestMethod]
        public void UpdateUser_Should_UpdateUserInDataHandler()
        {
            // Arrange
            string email = "user@example.com";
            string firstName = "John";
            string lastName = "Doe";
            string password = "password123";
            string newemail = "User@example.com";
            DateTime birthdate = DateTime.Now.AddYears(-1);
            User newUser = new Employee(firstName, password, email, lastName, birthdate);

            // Act
            userManager.UpdateUser(email, newUser);

            // Assert
            mockUserDataInterface.Verify(u => u.UpdateUser(email, newUser), Times.Once);
        }

        [TestMethod]
        public void GetUserByEmail_Should_ReturnUserFromDataHandler()
        {
            // Arrange
            string email = "user@example.com";
            string firstName = "John";
            string lastName = "Doe";
            string password = "password123";
            string prev_email = "user@example.com";
            DateTime birthdate = DateTime.Now.AddYears(-1);
            User expectedUser = new Employee(firstName, password, email, lastName, birthdate);

            mockUserDataInterface.Setup(u => u.GetUserByEmail(email)).Returns(expectedUser);

            // Act
            User actualUser = userManager.GetUserByEmail(email);

            // Assert
            Assert.AreEqual(expectedUser, actualUser);
        }

        [TestMethod]
        public void GetEmployees_Should_ReturnListOfEmployeesFromDataHandler()
        {
            // Arrange
            List<User> expectedEmployees = new List<User>(); 

            mockUserDataInterface.Setup(u => u.GetAllEmployees()).Returns(expectedEmployees);

            // Act
            List<User> actualEmployees = userManager.GetEmployees();

            // Assert
            Assert.AreEqual(expectedEmployees, actualEmployees);
        }

        [TestMethod]
        public void GetAdmins_Should_ReturnListOfAdminsFromDataHandler()
        {
            // Arrange
            List<User> expectedAdmins = new List<User>(); 

            mockUserDataInterface.Setup(u => u.GetAllAdministrators()).Returns(expectedAdmins);

            // Act
            List<User> actualAdmins = userManager.GetAdmins();

            // Assert
            Assert.AreEqual(expectedAdmins, actualAdmins);
        }

        [TestMethod]
        public void GetGuests_Should_ReturnListOfGuestsFromDataHandler()
        {
            // Arrange
            List<User> expectedGuests = new List<User>();

            mockUserDataInterface.Setup(u => u.GetAllGuests()).Returns(expectedGuests);

            // Act
            List<User> actualGuests = userManager.GetGuests();

            // Assert
            Assert.AreEqual(expectedGuests, actualGuests);
        }

        [TestMethod]
        public void GetAllUsers_Should_ReturnListOfAllUsersFromDataHandler()
        {
            // Arrange
            List<User> expectedUsers = new List<User>(); 
            List<User> expectedAdmins = new List<User>();
            List<User> expectedEmployees = new List<User>(); 
            List<User> expectedGuests = new List<User>(); 

            mockUserDataInterface.Setup(u => u.GetAllAdministrators()).Returns(expectedAdmins);
            mockUserDataInterface.Setup(u => u.GetAllEmployees()).Returns(expectedEmployees);
            mockUserDataInterface.Setup(u => u.GetAllGuests()).Returns(expectedGuests);

            // Act
            List<User> actualUsers = userManager.GetAllUsers();
            expectedUsers = expectedGuests.Cast<User>().Concat(expectedAdmins.Cast<User>().Concat(expectedEmployees.Cast<User>())).ToList();

            // Assert
            Assert.AreEqual(expectedUsers.Count(), actualUsers.Count());
        }
    }
}

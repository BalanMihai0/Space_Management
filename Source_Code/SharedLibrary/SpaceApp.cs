using SpaceLibrary;
using UserLibrary;

namespace SharedLibrary
{
    /// <summary>
    /// this class is used to call every other manager class in the UX/UI layer
    /// static methods: not an issue. This app should not expand by creating more instances of this
    /// a single instance of this class can be created, across all threads
    /// initialize in Program.cs => active for entire form application
    /// </summary>
    public sealed class SpaceApp
    {
        private static readonly Lazy<SpaceApp> lazy = new Lazy<SpaceApp>(() => new SpaceApp());

        public static SpaceApp Instance { get { return lazy.Value; } }

        public SpaceManager SpaceManager { get; private set; }
        public UserManager UserManager { get; private set; }
        
        private SpaceApp(IUserDataInterface userDataStorage, ISpaceDataInterface spaceDataStorage) 
        {
            SpaceManager = new SpaceManager(spaceDataStorage);
            UserManager = new UserManager(userDataStorage);
        }
        
        //managers instantiate with interface
        public static void Initialize(IUserDataInterface userDataStorage, ISpaceDataInterface spaceDataStorage)
        {
            if(Instance.SpaceManager != null || Instance.UserManager != null)
            {
                throw new Exception("Classes already initialized");
            }

            Instance.SpaceManager = new SpaceManager(spaceDataStorage);
            Instance.UserManager = new UserManager(userDataStorage);

        }

        private SpaceApp() { } //prevents another instance of the class being created

        public static SpaceApp GetInstance()
        {
            return lazy.Value;
        }
    }
}
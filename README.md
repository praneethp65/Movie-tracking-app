## Movie Tracker App:

This application is designed to help movie enthusiasts to keep track of the movies they have watched, and those they are currently watching. It provides a simple and efficient way to manage and keep track of movies watched. 

## Features:
1. User Authentication
->Login for Existing Users: Users who have already signed up can log in to the app using their email and password.
->Sign Up for New Users: New users can create an account by providing their email and password, enabling them to start tracking movies immediately.

2. Movie Listing Page
->View Added Movies: Once logged in, users are taken to the movie listing page where they can see all the movies they have added.
->Movie Details: Each movie in the list displays its title, director, date watched, completed/Not completed and a poster image.

3. Add New Movies: Users can add new movies to their list by providing details such as the movie title, director, date watched, completed/Not completed and a poster image. This feature ensures that users can keep their watched list up to date.
   
4. Update Movies: Users can update the details of movies they have already added. This feature is useful for correcting information or adding additional details to existing entries.
   
5. Delete Movies: Users have the option to delete movies from their list. This helps in maintaining an accurate and relevant list of movies they are interested in.
    
6. Mark Movies as Completed: Users can mark movies as completed once they have watched them. This feature helps users track their progress and easily see which movies they have already seen.
    
7. Logout: Users can securely log out of the app, ensuring that their movie data is protected and only accessible when they are logged in.
    
8. Data Management with Supabase: The app uses Supabase for database management and user authentication. This ensures secure and reliable data storage and retrieval.

# Design Patterns:
1.Singleton Pattern: Used in `MauiProgram.cs` to ensure that only one instance of services like `Supabase.Client`, `MoviesListingViewModel`, `AuthService`, and `DataService` is created and used throughout the application.

2.Observer Pattern: Implemented in all ViewModel files using the `ObservableObject` base class and `ObservableCollection<Movie>` from the CommunityToolkit.Mvvm package. This allows the UI to be notified of changes in the data.



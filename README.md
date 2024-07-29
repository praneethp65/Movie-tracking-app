# Movie Tracker App:

The Movie Tracker App is designed for movie enthusiasts to keep track of the movies they have watched and are currently watching. It provides a simple and efficient way to manage and organize your movie list.

# Features
## User Authentication
Login for Existing Users: Users can log in using their email and password.

Sign Up for New Users: New users can create an account to start tracking their movies.

## Movie Listing Page
View Added Movies: Users can see all the movies they have added.

Movie Details: Each movie entry includes the title, director, date watched, status (completed/not completed), and a poster image.

## Add New Movies
Users can add new movies by providing details such as the title, director, date watched, status, and a poster image.
## Update Movies
Users can update the details of movies they have already added.
## Delete Movies
Users can delete movies from their list to maintain an accurate and relevant collection.
## Mark Movies as Completed
Users can mark movies as completed once they have watched them.
## Logout
Users can securely log out of the app.
## Data Management with Supabase
The app uses Supabase for database management and user authentication, ensuring secure and reliable data storage and retrieval.

## Technologies Used
### Frontend:
MAUI (Multi-platform App UI): Used for building cross-platform applications.

XAML: Used for designing the user interface.

### Backend:

Supabase: Used for database management and user authentication.

C#: The primary programming language used in the application.

### Libraries and Frameworks:

CommunityToolkit.Mvvm: Used for MVVM (Model-View-ViewModel) architecture.

ObservableObject and ObservableCollection: Used for data binding and observing changes in data.

### Tools:
Visual Studio: The IDE used for development.

Git: Used for version control.

### Design Patterns
Singleton Pattern
Used in MauiProgram.cs to ensure only one instance of services like Supabase.Client, MoviesListingViewModel, AuthService, and DataService is created and used throughout the application.

Observer Pattern
Implemented in all ViewModel files using the ObservableObject base class and ObservableCollection<Movie> from the CommunityToolkit.Mvvm package. This allows the UI to be notified of changes in the data.



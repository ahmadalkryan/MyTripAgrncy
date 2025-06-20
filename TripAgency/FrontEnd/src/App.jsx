import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { useContext } from 'react';
import Login from './components/auth/login';
import Register from './components/auth/register';
import Home from './components/pages/home';
import Book from './components/pages/Book';
import AddCar from './components/pages/addCar';
import './App.css';
import { AuthProvider, AuthContext } from './AuthContext.jsx';

function AppRoutes() {
    const { isAuthenticated } = useContext(AuthContext);

    return (
        <Routes>
            <Route path="/login"
                element={!isAuthenticated ? <Login /> : <Navigate to="/home" replace />}
            />
            <Route path="/home"
                element={isAuthenticated ? <Home /> : <Navigate to="/login" replace />}
            />
            <Route path="/"
                element={<Navigate to={isAuthenticated ? "/home" : "/login"} replace />}
            />
            <Route path="/register"
                element={!isAuthenticated ? <Register /> : <Navigate to="/register" replace />}
            />
            <Route path="/book"
                element={isAuthenticated ? <Book /> : <Navigate to="/login" replace />}
            />
            <Route path="/add-car"
                element={isAuthenticated ? <AddCar /> : <Navigate to="/login" replace />}
            />
        </Routes>
    );
}

function App() {
    return (
        <AuthProvider>
            <BrowserRouter>
                <AppRoutes />
            </BrowserRouter>
        </AuthProvider>
    );
}

export default App;

import CreateUser from "./components/CreateUser";
import Users from "./components/Users";
import DeleteUser from "./components/DeleteUser";

const AppRoutes = [
    {
        index: true,
        element: <Users />
    },
    {
        path: '/create-user',
        element: <CreateUser />
    },
    {
        path: '/delete-user',
        element: <DeleteUser />
    }
];

export default AppRoutes;

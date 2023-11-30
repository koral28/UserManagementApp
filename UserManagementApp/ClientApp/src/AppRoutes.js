import CreateUser from "./components/CreateUser";
import Users from "./components/Users";

const AppRoutes = [
    {
        index: true,
        element: <Users />
    },
    {
        path: '/create-user',
        element: <CreateUser />
    }
];

export default AppRoutes;

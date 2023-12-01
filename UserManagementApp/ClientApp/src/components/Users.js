import React, { useEffect, useState } from 'react';
import { GetAllUsers } from "../Api/UsersApi";

const Users = () => {
    const [users, setUsers] = useState([])

    useEffect(() => {
        const fetchUsers = async () => {
            const allUsers = await GetAllUsers();
            setUsers(allUsers)
        }
        fetchUsers()
    }, [])

    return (
        <table className="striped-table">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>User Name</th>
                    <th>Email Address</th>
                    <th>Phone Number</th>
                </tr>
            </thead>
            <tbody>
                {users.length > 1 ? users.map((item, index) => (
                    <tr key={index}>
                        <td>{item.firstName}</td>
                        <td>{item.lastName}</td>
                        <td>{item.userName}</td>
                        <td>{item.email}</td>
                        <td>{item.phone}</td>
                    </tr>
                )) :
                    <tr key={users.firstName}>
                        <td>{users.firstName}</td>
                        <td>{users.lastName}</td>
                        <td>{users.userName}</td>
                        <td>{users.email}</td>
                        <td>{users.phone}</td>
                    </tr>}
            </tbody>
        </table>
    )
}

export default Users;
import React, { useEffect, useState } from 'react';

const Users = () => {
    const [users, setUsers] = useState([])

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('https://jsonplaceholder.org/users');
                if (!response.ok) {
                    throw new Error('Network response id not succeeded')
                }
                const data = await response.json();
                setUsers(data)

            } catch (e) {
                console.error('Fetch error:', e);
            }
        }
        fetchData()
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
                {users.map((item, index) => (
                    <tr key={index}>
                        <td>{item.id}</td>
                        <td>{item.firstname}</td>
                        <td>{item.id}</td>
                        <td>{item.firstname}</td>
                        <td>{item.id}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}

export default Users;
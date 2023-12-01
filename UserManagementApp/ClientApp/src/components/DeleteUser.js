import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { DeleteAUser } from "../Api/UsersApi";

const DeleteUser = () => {
    const [phone, setPhone] = useState();
    const navigate = useNavigate();

    const handleInputChange = (event) => {
        const value = event.target.value;
        setPhone(value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        DeleteAUser(phone)
        navigate('/');
    }

    return (
        <form onSubmit={handleSubmit}>
            <div className="mb-1">
                <label htmlFor="phone" className="form-label">User Phone Number</label>
                <input type="tel" className="form-control" name="phone" onChange={handleInputChange} />
            </div>
            <button type="submit" className="btn btn-primary">Delete User</button>
        </form>
    )
}

export default DeleteUser;

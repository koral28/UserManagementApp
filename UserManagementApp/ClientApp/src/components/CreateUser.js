import React, { useState } from 'react';
import { AddNewUser } from "../Api/UsersApi";
import { useNavigate } from 'react-router-dom';

const CreateUser = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        timeZone: '',
        userName: '',
        email: '',
        phone: '',
        aboutMe:''
    });

    const validation = () => {
        const regexName = /^[a-zA-Z\u0590-\u05FF]+$/;
        const regexUserName = /^[a-zA-Z0-9]+$/;
        const regexUserPhoneNumber = /^\+?\d{7,15}$/;
        if (!regexName.test(formData.firstName) || !regexName.test(formData.lastName)) {
            alert('Please enter only letters for the name field.');
            return false;
        }
        else if (!regexUserName.test(formData.userName)) {
            alert('Please enter only letters/numbers for the user name field.');
            return false;
        }
        else if (!regexUserPhoneNumber.test(formData.phone)) {
            alert('Please enter only valid phone number for the user phone field.');
            return false;
        }
        return true;
    }

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (validation()) {
            AddNewUser(formData)
            navigate('/');
        }
    }

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="firstName" className="form-label">First Name</label>
                <input type="text" className="form-control" name="firstName" onChange={handleInputChange}/>
            </div>
            <div className="mb-1">
                <label htmlFor="lastName" className="form-label">Last Name</label>
                <input type="text" className="form-control" name="lastName" onChange={handleInputChange}/>
            </div>
            <div className="mb-1">
                <label htmlFor="dropdownInput">Time Zone</label>
                <select
                    className="form-control"
                    name="timeZone"
                    value={formData.timeZone}
                    onChange={handleInputChange}
                >
                    <option value="">Select...</option>
                    <option value="europe/warsaw">europe/warsaw</option>
                    <option value="europe/london">europe/london</option>
                    <option value="unitedStates/california">unitedStates/california</option>
                    <option value="unitedStates/miami">unitedStates/miami</option>
                </select>
            </div>
            <div>
                <label htmlFor="userName" className="form-label">User Name</label>
                <input type="text" className="form-control" name="userName" onChange={handleInputChange}/>
            </div>
            <div>
                <label htmlFor="email" className="form-label">Email address</label>
                <input type="email" className="form-control" name="email" onChange={handleInputChange}/>
            </div>
            <div>
                <label htmlFor="phone" className="form-label">Phone Number</label>
                <input type="tel" className="form-control" name="phone" onChange={handleInputChange}/>
            </div>
            <div className="mb-3">
                <label htmlFor="aboutMe" className="form-label">About Me</label>
                <input type="text" className="form-control" name="aboutMe" maxLength={100} onChange={handleInputChange}/>
            </div>
            <button type="submit" className="btn btn-primary">Submit</button>
        </form>
    )
}

export default CreateUser;

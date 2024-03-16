import { useEffect, useState } from "react";
import Swal from "sweetalert2";
import { Modal, Button } from "react-bootstrap";
import { User } from "../entities/Interfaces";
import * as UserService from '../services/UserService';

export const AuthMenu = () => {
    const [user, setUser] = useState<User | undefined>(undefined);
    const [show, setShow] = useState(false);

    const handleClose = () => {
        setShow(false);
    };

    // Auth function, meter aqui la autenticacion y obtencion del token
    const getToken = async () => {
        const username = (document?.getElementById("fname") as HTMLInputElement | null)?.value;
        const password = (document?.getElementById("lname") as HTMLInputElement | null)?.value;
    
        if (!username || !password) {
            Swal.fire(
                "Oops...",
                "Username and Password Should not be Void",
                "warning",
            );
            return;
        }

        const currentUser = await UserService.AuthenticateUser(username, password);
        if (currentUser) {
            setUser(currentUser);
        } else {
            Swal.fire(
                "Oops...",
                "Invalid Credentials",
                "warning",
            );
        }
    
        handleClose();
    };

    return (
        <div className="container-icon">
            <div className="container-cart-icon" onClick={() => setShow(!show)}>
                <img src={process.env.PUBLIC_URL + `/images/Auth/${user ? 'icons8-user-50.png' : 'icons8-male-user-50.png'}`} />
                {
                    show ? <>
                        <Modal
                            show={show}
                            onHide={handleClose}
                            size="lg"
                            aria-labelledby="contained-modal-title-vcenter"
                            centered
                        >
                            <Modal.Header closeButton>
                            <Modal.Title>Login User</Modal.Title>
                            </Modal.Header>
                            <Modal.Body>
                            <form className="d-block">
                                <label className="col-md-3 col-sm-3">
                                <strong>Username: </strong>
                                </label>
                                <input
                                type="text"
                                id="fname"
                                name="fname"
                                className="col-md-8 col-sm-8"
                                required
                                />
                                <br />
                                <br />
                                <label className="col-md-3 col-sm-3">
                                <strong>Password: </strong>
                                </label>
                                <input
                                className="col-md-8 col-sm-8"
                                type="password"
                                id="lname"
                                name="lname"
                                required
                                />
                                <br />
                                <br />
                            </form>
                            </Modal.Body>
                            <Modal.Footer>
                            <div className="ml-auto">
                                <Button className="mr-3" variant="info" onClick={getToken}>
                                Login
                                </Button>
                                <Button variant="danger" onClick={handleClose}>
                                Close
                                </Button>
                            </div>
                            </Modal.Footer>
                        </Modal>
                    </> : null
                }
            </div>
        </div>
    );
}

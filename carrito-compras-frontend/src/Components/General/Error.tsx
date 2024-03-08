import React from "react";

interface Props {
    message: string;
}

const Error: React.FC<Props> = ({ message }) => <h2 className="text-center mt-3">{message}</h2>;

export default Error;

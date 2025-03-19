import React from 'react'
import './CustomButton.css'

interface ButtonProps {
    onClick: () => void;
    text: string;
    className?: string;
}

const CustomButton: React.FC<ButtonProps> = ({ onClick, text, className }) => {
    return (
        <button className={`custom-btn ${className}`} onClick={onClick}>
            {text}
        </button>
    );
};

export default CustomButton;
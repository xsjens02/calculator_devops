import { useNavigate } from "react-router-dom";
import CustomButton from "../components/CustomButton"
import { CalcTypes } from "../models/CalcTypes";
import "./HomePage.css"
const HomePage = () => {
    const navigate = useNavigate();

    return (
        <div className="home-container">
            <h1 className="home-title">Choose from these two options:</h1>
            <div className="button-group">
                <CustomButton onClick={() => navigate(`/calc/${CalcTypes.SIMPLE}`)} text="Simple Calculator" className="option-btn" />
                <CustomButton onClick={() => navigate(`/calc/${CalcTypes.CACHED}`)} text="Cached Calculator" className="option-btn" />
            </div>
        </div>
    );
};
export default HomePage;
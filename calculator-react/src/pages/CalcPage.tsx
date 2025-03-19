import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import CustomButton from "../components/CustomButton"
import { CalcTypes } from "../models/CalcTypes";
import { CalcFunctions } from "../models/CalcFunctions";
import { CalcService } from "../services/CalcService";
import { CalcUtil } from "../util/CalcUtil";
import "./CalcPage.css"
const CalcPage = () => {
    const navigate = useNavigate();
    
    const { type } = useParams();
    const calcType: CalcTypes = (type as CalcTypes) in CalcTypes ? (type as CalcTypes) : CalcTypes.SIMPLE;
    
    const calcService = new CalcService();
    const calcUtil = new CalcUtil(calcService);
    
    const [display, setDisplay] = useState("");
    const [memory, setMemory] = useState<string[]>([]);
    
    const fetchMemory = async () => {
        try {
            const data = await calcService.getMemory();
            setMemory(data);
        } catch (error) {
            console.log("Error fetching calculator memory: ", error);
        }
    }

    useEffect(() => {
        fetchMemory();
    }, []);
    
    const handleButtonClick = async (value: string) => {
        switch (value) {
            case "C": setDisplay(""); break;
            case "=": setDisplay(await calcUtil.arithmetic(calcType, display)); fetchMemory(); break;
            case "P": setDisplay(await calcUtil.factorialOrPrime(calcType, CalcFunctions.PRIME, display)); fetchMemory(); break;
            case "F": setDisplay(await calcUtil.factorialOrPrime(calcType, CalcFunctions.FAC, display)); fetchMemory(); break;
            default: setDisplay((prev) => prev + value); break;
        }
    };
    
    const buttons = [
        "P", "F", " ", "/",
        "7", "8", "9", "x",
        "4", "5", "6", "-",
        "1", "2", "3", "+",
        "C", "0", " ", "="
    ];

    return (
        <div className="page-container">
            <CustomButton onClick={() => navigate(-1)} text="Back" className="back-btn" />
            <div className="calc-wrapper">
                
                {/* calculator */}
                <div className="calc-container">
                    <div className="calc">
                        <div className="calc-display">{display || "0"}</div>
                        <div className="calc-grid">
                            {buttons.map((btnText) => (
                                <CustomButton onClick={() => handleButtonClick(btnText)} text={btnText} className="calc-btn" />
                            ))}
                        </div>
                    </div>
                </div>

                {/* calculator memory */}
                <div className="memory-box">
                    <h3>Calculator Memory:</h3>
                    <ul>
                        {memory.length > 0 ? 
                            (memory.map((item, index) => (<li key={index}>{item}</li>))) 
                            : (<li>No history....</li>)}
                    </ul>
                </div>
            </div>
        </div>
    );
};
export default CalcPage;
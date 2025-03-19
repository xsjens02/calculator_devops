import { CalcFunctions } from "../models/CalcFunctions";
import { CalcTypes } from "../models/CalcTypes";
import { CalcService } from "../services/CalcService";

export class CalcUtil {
    private service:CalcService;
    private errorMsg: string;
    constructor(service:CalcService) {
        this.service = service;
        this.errorMsg = "INVALID INPUT";
    }
    async arithmetic(calc:CalcTypes, expression:string): Promise<string> {
        const match = expression.match(/^(\d{1,10})([+\-x/])(\d{1,10})$/);
        if (!match) return this.errorMsg;
        
        const [, a, operator, b] = match;
        let func:CalcFunctions;

        switch (operator) {
            case "+": func = CalcFunctions.ADD; break;
            case "-": func = CalcFunctions.SUB; break;
            case "x": func = CalcFunctions.MULTI; break;
            case "/": func = CalcFunctions.DIV; break;
            default: return this.errorMsg;
        }

        return func ? this.executeCalc(calc, func, a, b) : this.errorMsg; 
    }
    
    async factorialOrPrime(calc:CalcTypes, func:CalcFunctions.FAC | CalcFunctions.PRIME , expression:string): Promise<string> {
        return /^\d+$/.test(expression) ? this.executeCalc(calc, func, expression) : this.errorMsg;
    }
    
    private async executeCalc(calc: CalcTypes, func: CalcFunctions, ...args: string[]): Promise<string> {
        try {
            return await this.service.getCalc(calc, func, ...args);
        } catch {
            return this.errorMsg;
        }
    }
}
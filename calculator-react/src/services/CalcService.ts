import { CalcFunctions } from "../models/CalcFunctions";
import { CalcTypes } from "../models/CalcTypes";

export class CalcService {
    private apiUrl: string | null;
    constructor() {
        this.apiUrl = import.meta.env.VITE_API_URL || 'http://79.76.48.213:5000/api';
    }
    
    async getCalc(calc:CalcTypes, func:CalcFunctions, a?:string, b?:string): Promise<string> {
        try {
            const url = b ?
                `${this.apiUrl}/${calc}/${func}?a=${a}&b=${b}` :
                `${this.apiUrl}/${calc}/${func}?a=${a}`;
            
            const response = await fetch(url, {
                    method: "GET",
                    headers: { "Content-Type": "application/json" }
                }
            );
            
            if (!response.ok) {
                const msg = await response.text();
                throw new Error(`Error: ${msg}`);
            }
            
            return await response.json();
        } catch (error) {
            throw new Error(`Error: ${error}`);
        }
    }
    
    async getMemory(): Promise<string[]> {
        try {
            const response = await fetch(`${this.apiUrl}/memory`, {
                method: "GET",
                headers: { "Content-Type": "application/json" }
            });
            
            if (!response.ok) {
                const msg = await response.text();
                throw new Error(`Error: ${msg}`);
            }
            
            return await response.json();
        } catch (error) {
            throw new Error(`Error: ${error}`);
        }
    }
}
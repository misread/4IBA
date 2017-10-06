package by.gsu.epamlab;

import java.util.ArrayList;
import java.util.Scanner;

import by.gsu.epamlab.interfaces.Memory;

public abstract class Calculator<T extends Number> implements Memory {
	public final String PLUS = "+";
	public final String MINUS = "-";
	public final String MULT = "*";
	public final String DIV = "/";
	public final String COS = "cos";
	public final String EXP = "exp";
	public final String SQRT = "sqrt";
	public final String M = "m";
	public final String MPLUS = "m+";
	public final String MMINUS = "m-";
	public final String MR = "mr";
	public final String MC = "mc";
	
	public static Calculator<Double> getCalculator(Scanner sc) {
		int type = sc.nextInt();
		switch (type) {
			case 1: return new Simple<Double>();
			case 2: return new MemorySimple<Double>();
			case 3: return new Engeneer<Double>();
			case 4: return new MemoryEngeneer<Double>();
			default: System.out.println("unsupported type of calculator"); return null;
		}
	}
	
	public double calculate(ArrayList<String> list) {
		double tmp = 0;
		double result = Double.parseDouble(list.get(0));
		int size = list.size();
							
		for (int i = 1; i < size; i++) {			
			try {					
				tmp = Double.parseDouble(list.get(i+1));
			}
			catch (NumberFormatException | NullPointerException | IndexOutOfBoundsException ex) {}
			finally {
				if (this instanceof MemorySimple<?> || this instanceof MemoryEngeneer<?>) {
					switch (list.get(i)) {
						case M: write(result); break;
						case MR: result = restore(); break;
						case MC: clear(); break;
						case MPLUS: plusM(result); break;
						case MMINUS: minusM(result); break;
						default: break;
					}
				}
				if (this instanceof Engeneer<?>) {
					switch (list.get(i)) {
						case PLUS: result = sum(result, tmp); break;
						case MINUS: result = sub(result, tmp); break;
						case MULT: result = mul(result, tmp); break;
						case DIV: result = div(result, tmp); break;
						case COS: result = cos(result); break;
						case EXP: result = exp(result); break;
						case SQRT: result = sqrt(result); break;
						default: break;
					}
				} 
				else {
					switch (list.get(i)) {
						case PLUS: result = sum(result, tmp); break;
						case MINUS: result = sub(result, tmp); break;
						case MULT: result = mul(result, tmp); break;
						case DIV: result = div(result, tmp); break;
						case COS: 
						case EXP: 
						case SQRT: System.err.println("unsupported operation"); break;
						default: break;
					}
				}
			}
		}
		System.out.println("result: " + result);
		return result;
	}
	
	public double sum(double x, double y){return 0;}
	public double sub(double x, double y){return 0;}
	public double mul(double x, double y){return 0;}
	public double div(double x, double y){return 0;}
	public double cos(double x){return 0;}
	public double exp(double x){return 0;}
	public double sqrt(double x){return 0;}
	public double clear(){return 0;}
	public double write(double x){return 0;}
	public double restore(){return 0;}
	public double plusM(double x){return 0;}
	public double minusM(double x){return 0;}

}
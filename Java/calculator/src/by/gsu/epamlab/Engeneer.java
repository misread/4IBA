package by.gsu.epamlab;

public class Engeneer<T extends Number> extends Simple<T> {	
	public Engeneer() {}		
	
	public double cos(double x) {
		return Math.cos(Math.toRadians(x));
	}	
	public double exp(double x) {
		return Math.exp(x);
	}	
	public double sqrt(double x) {
		return Math.sqrt(x);
	}
		
}
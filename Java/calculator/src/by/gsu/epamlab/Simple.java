package by.gsu.epamlab;

public class Simple<T extends Number> extends Calculator<T> {	
	public Simple() {}
		
	public double sum(double x, double y) {
		return x + y;
	}	
	public double sub(double x, double y) {
		return x - y;
	}	
	public double mul(double x, double y) {
		return x * y;
	}	
	public double div(double x, double y) {
		return x / y;
	}

}
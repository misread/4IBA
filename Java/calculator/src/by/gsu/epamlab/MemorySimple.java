package by.gsu.epamlab;

import by.gsu.epamlab.interfaces.Memory;

public class MemorySimple<T extends Number> extends Simple<T> implements Memory {
	private double m;
		
	public MemorySimple() {}
		
	public double clear() {
		return m = 0;
	}
	public double write(double x) {
		return m = x;
	}
	public double restore() {
		return m;
	}
	public double plusM(double x) {
		return m += x;
	}
	public double minusM(double x) {
		return m -= x;
	}
	
}
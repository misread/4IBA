package by.gsu.epamlab;

import by.gsu.epamlab.interfaces.Memory;

public class MemoryEngeneer<T extends Number> extends Engeneer<T> implements Memory {
	private double m;
	
	public MemoryEngeneer() {}

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
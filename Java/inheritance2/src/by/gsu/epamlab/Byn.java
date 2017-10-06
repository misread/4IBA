package by.gsu.epamlab;

public class Byn implements Comparable<Byn> {	
	private int value;
	
	public Byn() {
		this(0);
	}
	
	public Byn(int value) {
		this.value = value;
	}
	
	public Byn(int rubs, int coins) {
		this(rubs * 100 + coins);
	}
	
	public Byn(Byn byn) {
		this(byn.value);
	}
	
	public int getValue() {
		return value;
	}

	public void setValue(int value) {
		this.value = value;
	}
	
	public int getRubs() {
		return value / 100;
	}
	
	public int getCoins() {
		return value % 100;
	}
	
	public Byn add(Byn byn) {
		value += byn.value;
		return this;
	};
	
	public Byn sub(Byn byn) {
		value -= byn.value;
		return this;
	}
	
	public Byn mul(int k) {
		value *= k;
		return this;
	}
	
	public Byn mul(double k, RoundingMode mode) {
		switch(mode) {
			case ROUND_CEIL : value = (int)Math.ceil(value * k); break; // roundUp
			case ROUND_FLOOR : value = (int)Math.floor(value * k); break; // roundDown
			case ROUND_COINS : value = (int)Math.round(value * k); break;
			case ROUND_RUBS : value = (int)Math.round(value / 100) * 100; break;
			default : break;
		}
		return this;
	}
	
	public Byn div(int k) {
		value /= k;
		return this;
	}
		
	@Override
	public String toString(){	
		return String.format("%d.%02d", value / 100, value % 100);
	}	
	
	public boolean equals(Object obj) {
		if (!(obj instanceof Byn)) {
        	return false;
        }    
        return this.value == ((Byn)obj).value;       
	}
	
	public int compareTo(Byn byn) {
		return this.value - byn.value;
	}
}

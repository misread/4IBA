package by.gsu.epamlab.beans;

public class Byn implements Comparable<Byn> {
	private int value;
	
	public Byn() {
		this(0);
	}
	
	public Byn(int value) {
		this.value = value;
	}
	
	public Byn(int rubs, int coins) {
		this.value = rubs * 100 + coins;
	}
	
	public Byn(Byn byn) {
		this(byn.value);
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
	}
	
	public Byn sub(Byn byn) {
		value -= byn.value;
		return this;
	}
	
	public Byn mul(int k) {
		value *= k;
		return this;
	}
	
	public String toString() {
		int coins = getCoins();
		return getRubs() + "." + (coins < 10 ? "0" : "") + coins;
	}
	
	public int compareTo(Byn byn) {
		return value - byn.value;
	}
	@Override
	public int hashCode() {
		final int prime = 31;
		return prime + value;
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (!(obj instanceof Byn))
			return false;
		Byn other = (Byn)obj;
		if (value != other.value)
			return false;
		return true;
	}
}

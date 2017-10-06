package by.gsu.epamlab;

public class PriceDiscountPurchase extends AbstractPurchase {
	private Byn discount;
		
	public PriceDiscountPurchase(Commodity commodity, int number, int discount) { 
		super(commodity, number);
		this.discount =  new Byn(discount);
	}

	public Byn getDiscount() {
		return discount;
	}

	public void setDiscount(int discount) {
		this.discount = new Byn(discount);
	}	
	
	public Byn getFinalCost(int baseCost){
		Byn cost = new Byn(baseCost - discount.getValue() * super.getNumber());
		return cost; 
	}	
	
	protected String fieldsToString() {
		return super.fieldsToString() + ";" + discount;
	}
}

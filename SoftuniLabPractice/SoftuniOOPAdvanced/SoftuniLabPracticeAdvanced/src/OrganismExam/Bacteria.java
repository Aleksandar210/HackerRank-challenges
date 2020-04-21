package OrganismExam;

public class Bacteria extends Microbe {

	protected Bacteria(String id, int health, int positionRow, int positionCol, int addit) {
		super(id, health, positionRow, positionCol, addit);
		
	}
	
	@Override
	public int getEnergy() {
		return (this.getHealth()+this.getAdditional())/4;
	}

}

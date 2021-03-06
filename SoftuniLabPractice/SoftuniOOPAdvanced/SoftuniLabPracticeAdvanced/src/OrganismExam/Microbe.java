package OrganismExam;

public abstract class Microbe extends Cell {

	protected Microbe(String id, int health, int positionRow, int positionCol, int addit) {
		super(id, health, positionRow, positionCol, addit);
		
	}
	
	@Override
	public String toString() {
		String print = String.format("Microbe:%s HEALTH: %d ENERGY: %d VIRULANCE: %d",this.getId(),this.getHealth(),this.getEnergy(),this.getAdditional());
		return print;
	}
	
	@Override
	public void attack(Cell enemyCell) {
		while(!(enemyCell.getHealth()<=0) || !(this.getHealth()<=0)) {
			enemyCell.Attacked(this.getEnergy());
			if(enemyCell.getHealth()>0) {
				this.Attacked(enemyCell.getEnergy());
			}else {
				break;
			}
		}
	}

}

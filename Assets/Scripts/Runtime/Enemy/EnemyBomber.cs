namespace Runtime.Enemy
{
    public class EnemyBomber : EnemyBase
    {
        public float bomberSpeed = 15f;
        protected override void Start()
        {
            moveSpeed = this.bomberSpeed;
        }

        public override void Attack()
        {
         
            
        }
    }
}
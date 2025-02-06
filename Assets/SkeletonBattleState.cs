using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform player;
    private Enemy_Skeleton enemy;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;

    }
    public override void Update()
    {
        base.Update();

        if(enemy.IsPlayerDetected())
        {
            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if(CanAttack())
                stateMachine.ChangeState(enemy.attackState);
            }
        }

        if(player.position.x > enemy.transform.position.x)      
            moveDir = 1;    
        else
            moveDir = -1;
        
        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.linearVelocity.y);



    }

    public override void Exit()
    {
        base.Exit();
    }


    private bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttack + enemy.attackCooldown)
        {
            enemy.lastTimeAttack = Time.time;
            return true;
        }
        Debug.Log("attack is cool down");
            return false;
        
    }
}

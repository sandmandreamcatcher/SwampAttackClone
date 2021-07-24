using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _atackDelay;

    private Animator _animator;
    private float _lastAttackTime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _atackDelay;
        }

        _lastAttackTime -= Time.deltaTime;
    }


    private void Attack(Player target)
    {
        _animator.Play("Attack");
        target.ApplyDamage(_damage);
    }
}
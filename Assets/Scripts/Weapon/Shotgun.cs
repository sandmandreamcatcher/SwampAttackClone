using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField][Range(1,4)] private int _bulletsInShoot;
    [SerializeField] private bool _RandomBulletCount = true;
    private Transform[] _shootPositions = new Transform[4];

    public override void Shoot(Transform shootPoint)
    {
        if (_RandomBulletCount == true)
            _bulletsInShoot = Random.Range(1, 5);

        for (int i = 0; i < _bulletsInShoot; i++)
        {
            _shootPositions[i] = shootPoint;
        }

        ShootWithFewBullets();
    }

    private void ShootWithFewBullets()
    {
        float currentPos = 0f;

        for (int i = 0; i < _bulletsInShoot; i++)
        {

            Instantiate(Bullet, new Vector2(_shootPositions[i].position.x, _shootPositions[i].position.y + currentPos), Quaternion.identity);
            currentPos += 0.05f;
        }
    }
}
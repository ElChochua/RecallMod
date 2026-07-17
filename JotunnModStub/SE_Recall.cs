using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RecallMod
{

    public class SE_Recall : StatusEffect
    {
        public float m_recallChannelTime = 6f;
        private float _timer;
        private Player _player;
        private bool _cancelled;

        public override void Setup(Character character)
        {
            base.Setup(character);
            _player = character as Player;
            _timer = 0f;
            _cancelled = false;

        }

        public override void UpdateStatusEffect(float dt)
        {
            base.UpdateStatusEffect(dt);
            if (_cancelled || _player == null) return;
            _timer += dt;

            if(_timer >= m_recallChannelTime)
            {
                TeleportToSpawn();
                _player.GetSEMan().RemoveStatusEffect(this);
            }
        }
        public override void OnDamaged(HitData hit, Character attacker)
        {
            base.OnDamaged(hit, attacker);
            _cancelled = true;
            _player.Message(MessageHud.MessageType.Center, "Recall Cancelled");
            _player.GetSEMan().RemoveStatusEffect(this);
        }

        private void TeleportToSpawn()
        {
            if (Game.instance.GetPlayerProfile().HaveCustomSpawnPoint())
            {
                _player.TeleportTo(Game.instance.GetPlayerProfile().GetCustomSpawnPoint(),_player.transform.rotation, true);
            }
            else
            {
                _player.Message(MessageHud.MessageType.Center, "No Bed Position Found, Teleporting to StartTemple");
                if (ZoneSystem.instance.GetLocationIcon("StartTemple", out var templePos)) _player.TeleportTo(templePos, _player.transform.rotation, true);
            }

        }
    }
}

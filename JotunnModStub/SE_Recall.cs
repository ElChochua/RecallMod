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
            RecallHud.Show();
            RecallHud.SetText("Recalling");

        }

        public override void UpdateStatusEffect(float dt)
        {
            base.UpdateStatusEffect(dt);
            if (_cancelled || _player == null) return;
            _timer += dt;
            float progress = _timer / m_recallChannelTime;
            Jotunn.Logger.LogInfo($"[Recall] timer={_timer:F2} channelTime={m_recallChannelTime:F2} progress={progress:F2}");
            RecallHud.SetProgress(progress);

            if (_timer >= m_recallChannelTime)
            {
                _player.Message(MessageHud.MessageType.Center, "Recalling...");
                TeleportToSpawn();
                RecallHud.Hide();
                _player.GetSEMan().RemoveStatusEffect(this);
            }
        }
        public override void Stop()
        {
            base.Stop();
            RecallHud.Hide();
        }

        public override void OnDamaged(HitData hit, Character attacker)
        {
            base.OnDamaged(hit, attacker);
            _cancelled = true;
            RecallHud.SetText("Recall Cancelled...");
            RecallHud.Hide();
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

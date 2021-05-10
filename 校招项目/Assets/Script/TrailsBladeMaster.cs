using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("PocketRPG/Blade Master")]
public class TrailsBladeMaster : MonoBehaviour
{
	public GameObject WiresParticles;

	public GameObject LineRenderPrefab;

	public bool UseSkinnedMeshRenderer;

	public SkinnedMeshRenderer TargetSkinneMeshRenderer;

	public float MaxDistance;

	public int MaxLineRenderers;

	public int MaxConnections;



	private ParticleSystem _particleSystem;

	private ParticleSystem.MainModule _particleSystemMainMoudle;

	private ParticleSystem.Particle[] _particles;

	private LineRenderer[] _lineRenderers;

	private Transform _psTransform;



    private void Start()
    {
		_lineRenderers = new LineRenderer[MaxLineRenderers];

		var go = Instantiate(WiresParticles, transform.position, WiresParticles.transform.rotation);

		go.transform.parent = transform;

		_particleSystem = go.GetComponent<ParticleSystem>();

		var sh = _particleSystem.shape;

		if(UseSkinnedMeshRenderer)
        {
			sh.skinnedMeshRenderer = TargetSkinneMeshRenderer;

        }
		_particleSystemMainMoudle = _particleSystem.main;

		_psTransform = _particleSystem.GetComponent<Transform>();

		int maxParticles = _particleSystemMainMoudle.maxParticles;

		_particles = new ParticleSystem.Particle[maxParticles];
    }

    private void Update()
    {
		var liveParticles = _particleSystem.GetParticles(_particles);

		var lineRendersCount = _lineRenderers.Length;

		var lrIndex = 0;

		for(int i = 0; i < liveParticles; ++i)
        {
			var plPos = _particles[i].position;

			var particleConnection = 0;

            for (int j = 0; j < liveParticles; j++)
            {
				if(particleConnection == MaxConnections || lrIndex == MaxLineRenderers)
                {
					break;
				}

				var p2Pos = _particles[j].position;

				float distance = Vector3.Distance(p2Pos, plPos);

				if(distance > MaxDistance)
                {
					continue;
                }

				LineRenderer lineRenderer;

				if(_lineRenderers[lrIndex] == null)
                {
					var go = Instantiate(LineRenderPrefab, _psTransform.position, _psTransform.rotation);

					lineRenderer = go.GetComponent<LineRenderer>();

					lineRenderer.transform.parent = _psTransform.transform;

					_lineRenderers[lrIndex] = lineRenderer;
                }

				lineRenderer = _lineRenderers[lrIndex];

				lineRenderer.enabled = true;

				lineRenderer.SetPosition(0, plPos);

				lineRenderer.SetPosition(1, p2Pos);

				lrIndex++;

				particleConnection++;

            }

		}
		var outdateLineRenderers = lineRendersCount - lrIndex;

		for (int i = 0; i < outdateLineRenderers; i++)
		{
			if (_lineRenderers[i] != null)
			{
				_lineRenderers[i].enabled = false;
			}

		}

	}
}

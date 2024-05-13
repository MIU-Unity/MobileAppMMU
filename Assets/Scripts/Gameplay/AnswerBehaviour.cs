using System;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Common.Utility;

namespace Gameplay
{
    public class Variant
    {
        public int id;
        public string name;
        public bool isRight;
        public bool isShow;
    } 
    
    public class AnswerBehaviour : Singleton<MonoBehaviour>
    {
        private Variant[] _variants;
        [CanBeNull] private Variant _selectedVariant;
        
        public static Action<Variant> OnVariantSelect;
        
        public void Initialize(Variant[] variants)
        {
            _variants = variants;
        }
        
        public Variant[] GetVariants()
        {
            return _variants;
        }
        
        public Variant GetVariant(int id)
        {
            Variant foundedVariant = Array.Find(_variants, v => v.id == id);
            
            return foundedVariant;
        }

        public void SelectVariant(int id)
        {
            _selectedVariant = GetVariant(id);
            OnVariantSelect.Invoke(_selectedVariant);
        }

        public Variant GetSelectedVariant()
        {
            return _selectedVariant;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User_JSON
{
    [SerializeField] public string _userId;
    [SerializeField] public string _nickName;
    [SerializeField] public bool _isLocal;
    [SerializeField] public int _avatarId;
    [SerializeField] public PersonalData _personalData;

    public User_JSON(string UserId, string NickName, bool IsLocal, PersonalData PersonalData = null, int AvatarId = 0) {
        this._userId = UserId;
        this._nickName = NickName;
        this._isLocal = IsLocal;
        this._avatarId = AvatarId;
        this._personalData = PersonalData;
    }
}

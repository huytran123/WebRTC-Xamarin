﻿// onotseike@hotmail.comPaula Aliu
using System;

using WebRTC.Classes;

namespace WebRTC.RTC.Abstraction
{
    #region ConnectionState Enum

    public enum ConnectionState
    {
        New,
        Connected,
        Closed,
        Error
    }

    #endregion


    public interface IRTCClient<in TConnectionParam> where TConnectionParam : IConnectionParameters
    {
        #region Enum(s)

        ConnectionState State { get; }

        #endregion

        #region Method(s)

        void Connect(TConnectionParam _connectionParameters);
        void Disconnect();
        void SendOfferSdp(SessionDescription _sessionDescription);
        void SendAnswerSdp(SessionDescription _sessionDescriotion);
        void SendLocalIceCandidate(IceCandidate candidate);
        void SendLocalIceCandidateRemovals(IceCandidate[] _candidates);

        #endregion
    }

    public interface ISignalingEvents<in TSignalParam> where TSignalParam : ISignalingParameters
    {
        #region Method(s)

        void OnChannelConnected(TSignalParam _signalParameters);
        void OnChannelClose();
        void OnChannelError(string _description);
        void OnRemoteDescription(SessionDescription _sessionDescription);
        void OnRemoteIceCandidate(IceCandidate _candidate);
        void OnRemoteIceCandidatesRemoved(IceCandidate[] _candidates);

        #endregion
    }

    public interface ISignalingParameters
    {
    }

    public interface IConnectionParameters
    {
    }
}

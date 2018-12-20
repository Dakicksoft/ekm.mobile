﻿using OperationResult.Tags;

namespace OperationResult
{
    /// <summary>
    /// Status of operation (without Value and Error fields)
    /// </summary>
    public struct Status
    {
        private readonly bool _isSuccess;

        public bool IsSuccess => _isSuccess;
        public bool IsError => !_isSuccess;

        private Status(bool isSuccsess)
        {
            _isSuccess = isSuccsess;
        }

        public static implicit operator bool(Status status)
        {
            return status._isSuccess;
        }

        private static Status SuccessStatus = new Status(true);

        public static implicit operator Status(SuccessTag tag)
        {
            return SuccessStatus;
        }

        private static Status ErrorStatus = new Status(false);

        public static implicit operator Status(ErrorTag tag)
        {
            return ErrorStatus;
        }
    }

    /// <summary>
    /// Status of operation (without Value but with Error field)
    /// </summary>
    /// <typeparam name="TError">Type of Error field</typeparam>
    public struct Status<TError>
    {
        private readonly bool _isSuccess;

        public readonly TError Error;

        public bool IsSuccess => _isSuccess;
        public bool IsError => !_isSuccess;

        private Status(bool isSuccsess)
        {
            _isSuccess = isSuccsess;
            Error = default(TError);
        }

        private Status(TError error)
        {
            _isSuccess = false;
            Error = error;
        }

        public static implicit operator bool(Status<TError> status)
        {
            return status._isSuccess;
        }

        private static Status<TError> SuccessStatus = new Status<TError>(true);

        public static implicit operator Status<TError>(SuccessTag tag)
        {
            return SuccessStatus;
        }

        public static implicit operator Status<TError>(ErrorTag<TError> tag)
        {
            return new Status<TError>(tag.Error);
        }
    }

    /// <summary>
    /// Status of operation (without Value but with different Errors)
    /// </summary>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    public struct Status<TError1, TError2>
    {
        private readonly bool _isSuccess;

        public readonly object Error;

        public bool IsSuccess => _isSuccess;
        public bool IsError => !_isSuccess;

        public bool HasError<TError>() => Error is TError;
        public TError GetError<TError>() => (TError)Error;

        private Status(bool IsSuccess)
        {
            _isSuccess = IsSuccess;
            Error = null;
        }

        private Status(object error)
        {
            _isSuccess = false;
            Error = error;
        }

        public static implicit operator bool(Status<TError1, TError2> status)
        {
            return status._isSuccess;
        }

        private static Status<TError1, TError2> SuccessStatus = new Status<TError1, TError2>(true);

        public static implicit operator Status<TError1, TError2>(SuccessTag tag)
        {
            return SuccessStatus;
        }

        public static implicit operator Status<TError1, TError2>(ErrorTag<TError1> tag)
        {
            return new Status<TError1, TError2>(tag.Error);
        }

        public static implicit operator Status<TError1, TError2>(ErrorTag<TError2> tag)
        {
            return new Status<TError1, TError2>(tag.Error);
        }
    }


    /// <summary>
    /// Status of operation (without Value but with different Errors)
    /// </summary>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    /// <typeparam name="TError3">Type of third Error</typeparam>
    public struct Status<TError1, TError2, TError3>
    {
        private readonly bool _isSuccess;

        public readonly object Error;

        public bool IsSuccess => _isSuccess;
        public bool IsError => !_isSuccess;

        public bool HasError<TError>() => Error is TError;
        public TError GetError<TError>() => (TError)Error;

        private Status(bool IsSuccess)
        {
            _isSuccess = IsSuccess;
            Error = null;
        }

        private Status(object error)
        {
            _isSuccess = false;
            Error = error;
        }

        public static implicit operator bool(Status<TError1, TError2, TError3> status)
        {
            return status._isSuccess;
        }

        private static Status<TError1, TError2, TError3> SuccessStatus = new Status<TError1, TError2, TError3>(true);

        public static implicit operator Status<TError1, TError2, TError3>(SuccessTag tag)
        {
            return SuccessStatus;
        }

        public static implicit operator Status<TError1, TError2, TError3>(ErrorTag<TError1> tag)
        {
            return new Status<TError1, TError2, TError3>(tag.Error);
        }

        public static implicit operator Status<TError1, TError2, TError3>(ErrorTag<TError2> tag)
        {
            return new Status<TError1, TError2, TError3>(tag.Error);
        }

        public static implicit operator Status<TError1, TError2, TError3>(ErrorTag<TError3> tag)
        {
            return new Status<TError1, TError2, TError3>(tag.Error);
        }
    }
}
import React from 'react';
import { withToastManager } from 'react-toast-notifications';


const Success = ({ content, toastManager }) => (
    <button onClick={() => toastManager.add(content, {
      appearance: 'success',
      autoDismiss: true,
      pauseOnHover: true,
    })}>
      Add Toast
    </button>
  );
  
  export const SuccessAlert  = withToastManager(Success);
  

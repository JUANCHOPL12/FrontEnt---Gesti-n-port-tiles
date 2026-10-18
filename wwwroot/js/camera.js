let stream = null;

export async function startCamera(videoId) {
    try {
        stream = await navigator.mediaDevices.getUserMedia({ 
            video: { width: { ideal: 1280 }, height: { ideal: 720 }, facingMode: "user" }, 
            audio: false 
        });
        const video = document.getElementById(videoId);
        if (video) {
            video.srcObject = stream;
            await video.play();
            return true;
        }
        return false;
    } catch (err) {
        console.error("Error al acceder a la cámara:", err);
        return false;
    }
}

export function capturePhoto(videoId, canvasId) {
    const video = document.getElementById(videoId);
    const canvas = document.getElementById(canvasId);
    
    if (video && canvas) {
        const context = canvas.getContext('2d');
        canvas.width = video.videoWidth || 640;
        canvas.height = video.videoHeight || 480;
        context.drawImage(video, 0, 0, canvas.width, canvas.height);
        
        const base64Data = canvas.toDataURL('image/jpeg', 0.8);
        stopCamera();
        return base64Data;
    }
    return null;
}

export function stopCamera() {
    if (stream) {
        stream.getTracks().forEach(track => track.stop());
        stream = null;
    }
}
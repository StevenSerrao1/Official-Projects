import {useState, useEffect} from "react";
import { Image } from "../../Sections/Projects/types/interfaces";
import "./Carousel.css";

interface CarouselComponentProps {
  images: Image[];
}

const CarouselComponent: React.FC<CarouselComponentProps> = ({ images }) => { // Accept images as props
  const [currentIndex, setCurrentIndex] = useState(0);

  // Handle next image navigation
  const nextImage = () => {
    if (images.length > 0) {
      setCurrentIndex((prev) => (prev + 1) % images.length);
    }
  };

  // Handle previous image navigation
  const prevImage = () => {
    if (images.length > 0) {
      setCurrentIndex((prev) => (prev - 1 + images.length) % images.length);
    }
  };

  return (
    <div className="carousel-component">
      <div className="carousel-image-container">
        {images.length > 0 && (
          <img
            src={images[currentIndex].imageUrl}
            alt={images[currentIndex].altText || `Slide ${currentIndex + 1}`}
            className="carousel-image"
          />
        )}
      </div>
      <div className="carousel-controls">
        <button onClick={prevImage} className="carousel-button">Previous</button>
        <button onClick={nextImage} className="carousel-button">Next</button>
      </div>
    </div>
  );
};

export default CarouselComponent;